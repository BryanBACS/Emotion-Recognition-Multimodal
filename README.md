# Emotion-Recognition-Multimodal

Código para la tesis que tiene como objetivo desarrollar un sistema que implemente modelos multimodales para el reconocimiento de emociones mediante la modalidad facial y de texto. El propósito del modelo y sistema es proporcionar retroalimentación en tiempo real al docente y permitirle ajustar sus estrategias pedagógicas de acuerdo a las emociones detectadas en los estudiantes.

Hasta el momento se ha llevado a cabo las siguientes pruebas:


| Modalidad facial  |  Accuracy |
| ------------- | ------------- |
| Modelo Paper 10 layers CNN + MaxPooling + Dropout   | 68.65% |
| Modelo Paper 10 layers CNN + BatchNormalization + MaxPooling + Dropout   | 71.03%  |
| InceptionV3 + BatchNormalization   | 34.95%  |
| ResNet50 + BatchNormalization   | 33.87%  |
| VGG19 + BatchNormalization   | 73.30% (presenta overfitting) | 
| Mini-Xception + BatchNormalization   | 50.07% |
| Keras Tunner 4 layers CNN + BatchNormalization + MaxPooling + Dropout   | 71.03% |
| XceptionNet + BatchNormalization  | 74.64% (presenta overfitting)  |
| DenseNet  | 43.30%  |
| vit-b/16  | [En desarrollo]  |


| Modalidad texto  |  Accuracy |
| ------------- | ------------- |
| LSTM + Embedding Keras   | 14.38%  |
| BiLSTM + Embedding Keras   | 74.36%  |
| BiLSTM + Embedding GloVe   | 55.45%  |
| BiLSTM + Embedding Word2Vec   | 49.71%  |
| Paper BiLSTM + Embedding Word2Vec + FastText   | 51.78%  |
| Bert + CNN   | 98.40% |
| Bert + BiLSTM  | [En desarrollo] |


División de datos: HoldOut
- 80% train, 10% test, 10% val
- Para la modalidad facial y de texto se hizo uso de aplicación de generadores para ingresar los datos mediante batches


Mejores modelos obtenidos:
- Texto: Bert + CNN
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/0317a677-e08d-409d-97a0-2aa552535e30)
  Accuracy: 98.40%
  F1-Score: [En desarrollo]
  Recall: [En desarrollo]
  Batch_size = 64

- Facial: Keras Tunner 4 layers CNN + BatchNormalization + MaxPooling + Dropout
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/b2a6df27-547c-4d95-b2ef-353c95db27fe)
  Accuracy: 71.03%
  F1-Score: 69%
  Recall: 69%
  Batch_size = 64
  
