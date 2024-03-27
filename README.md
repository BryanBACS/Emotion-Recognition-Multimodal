# Emotion-Recognition-Multimodal

Autores: BRYAN CABEZAS, PABLO SCHWARZENBERG

Código para la tesis que tiene como objetivo desarrollar un sistema que implemente modelos multimodales para el reconocimiento de emociones mediante la modalidad facial y de texto. El propósito del modelo y sistema es proporcionar retroalimentación en tiempo real al docente y permitirle ajustar sus estrategias pedagógicas de acuerdo a las emociones detectadas en los estudiantes.

Hasta el momento se han llevado a cabo las siguientes pruebas:


| Modalidad facial  |  Accuracy |
| ------------- | ------------- |
| Modelo Paper 10 layers CNN + MaxPooling + Dropout   | 68.65% |
| Modelo Paper 10 layers CNN + BatchNormalization + MaxPooling + Dropout   | 71.03%  |
| InceptionV3 + BatchNormalization   | 34.95%  |
| ResNet50 + BatchNormalization   | 33.87%  |
| VGG19 + BatchNormalization   | 73.30% (presenta overfitting) | 
| Mini-Xception + BatchNormalization   | 50.07% |
| Keras Tunner 4 layers CNN + BatchNormalization + MaxPooling + Dropout - 64 batch | 71.03% |
| Keras Tunner 4 layers CNN + BatchNormalization + MaxPooling + Dropout - 128 batch | 75.48% |
| XceptionNet + BatchNormalization  | 74.64% (presenta overfitting)  |
| DenseNet  | 43.30%  |
| vit-b/16  | [En desarrollo]  |
| Ensemble promedio 3 best models - 64 batch | 62.93%  |
| Ensemble promedio 3 best models - 100 batch | 57.37%  |
| Ensemble promedio 2 best models - 64 batch | 69.83%  |
| Ensemble promedio 2 best models - 100 batch | 67.30%  |
| Ensemble ponderado 2 best models - 64 batch | 64.71%  |
| Ensemble ponderado 2 best models - 100 batch | 61.42%  |






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
  - Accuracy: 98.40%
  - F1-Score: [En desarrollo]
  - Recall: [En desarrollo]
  - Batch_size = 64

- Facial: Keras Tunner 4 layers CNN + BatchNormalization + MaxPooling + Dropout
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/59c9cd5e-6aac-41d0-8d8d-311f1aec758e)
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/e40d5b7b-db19-4671-9985-965e895a400b)
  - Accuracy: 75.48%
  - F1-Score: 76%
  - Recall: 76%
  - Batch_size = 128
 
Modelo multimodal: [En desarrollo]

Sistema:
- Para el desarrollo del sistema se va hacer uso del framework Django para el Backend e implementación del modelo multimodal. Para el lado del Frontend se va hacer uso de React.
- El sistema recopilará la información de entrada facial y texto del estudiante al usar el sistema, lo cual, se entregará al modelo multimodal para obtener la emoción final que el estudiante obtuvo en cada pregunta de forma individual y total mediante el promedio.

Tabla de requerimientos: [En desarrollo]

Diagrama del sistema: [En desarrollo]
