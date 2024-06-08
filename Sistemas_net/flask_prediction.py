from flask import Flask, request, jsonify
from transformers import AutoTokenizer, TFRobertaModel
import tensorflow as tf
from keras.models import load_model
import numpy as np
import re

app = Flask(__name__)

tokenizer = AutoTokenizer.from_pretrained("roberta-base")
model = TFRobertaModel.from_pretrained("roberta-base")

def custom_objects_fn():
    return {'TFRobertaModel': TFRobertaModel}

model = load_model('BERT_CNN_model_best_18_val_0.7862.h5', custom_objects=custom_objects_fn())
print("Modelo cargado")

clases = ["angry", "disgust", "fear", "happy", "neutral", "sad", "surprise"]

def clean_emotion_text(texto):
    if isinstance(texto, list):  # En caso de ser lista toma el primer valor
        texto = texto[0]
    if texto.startswith('[') and texto.endswith(']'):  # Si empieza y termina con [ ] los elimina
        texto = texto[1:-1]
    texto = texto.lower()
    texto = texto.replace('á', '')
    texto = texto.replace('\n', '')
    texto = texto.replace('[]', "'")
    texto = texto.replace('’', "'")
    texto = re.sub(r"@[A-Za-z0-9]+", ' ', texto)
    texto = re.sub(r"https?://[A-Za-z0-9./]+", ' ', texto)
    texto = re.sub(r"[^a-zA-Z.'!?]", ' ', texto)
    texto = re.sub(r"#", ' ', texto)
    texto = re.sub(r"\s(?=\')", "", texto)  # Eliminar los espacios que une los apóstrofes
    texto = texto.replace("' ", "'")
    texto = re.sub(r" +", ' ', texto)
    return texto

def preprocessing_text_Roberta(text):
    input_ids = []
    attention_masks = []
    inputs = tokenizer(text, padding='max_length', truncation=True, max_length=300, return_tensors='tf')
    input_ids.append(inputs['input_ids'])
    attention_masks.append(inputs['attention_mask'])
    return np.array(input_ids), np.array(attention_masks)

@app.route('/predict', methods=['POST'])
def predict_emotion():
    data = request.get_json()
    text = data['text']
    text = clean_emotion_text(text)

    input_ids, attention_mask = preprocessing_text_Roberta(text)
    input_ids_input = np.squeeze(input_ids, axis=1)
    attention_mask_input = np.squeeze(attention_mask, axis=1)

    emotions = model.predict([input_ids_input, attention_mask_input])
    emotions = np.argmax(emotions)
    print("emocion",emotions)
    result = clases[emotions]
    return jsonify(result)

if __name__ == '__main__':
    app.run(port=5000)
