# Emotion-Recognition-Multimodal

Autores: BRYAN CABEZAS, PABLO SCHWARZENBERG

Código para la tesis que tiene como objetivo desarrollar un sistema que implemente modelos multimodales para el reconocimiento de emociones mediante la modalidad facial y de texto. El propósito del modelo y sistema es proporcionar retroalimentación en tiempo real al docente y permitirle ajustar sus estrategias pedagógicas de acuerdo a las emociones detectadas en los estudiantes.

Hasta el momento se han llevado a cabo las siguientes pruebas, las cuales, estan ordenadas de menor a mayor valor de métricas:


| Modalidad facial  |  Accuracy |
| ------------- | ------------- |
| ResNet50 + BatchNormalization   | 33.87%  |
| InceptionV3 + BatchNormalization   | 34.95%  |
| DenseNet  | 43.30%  |
| MobileNet  | 46.29%  |
| Mini-Xception + BatchNormalization   | 50.07% |
| VIT-b/16  | 55.95% |
| Ensemble promedio 3 best models - 100 batch | 57.37%  |
| Ensemble ponderado 2 best models - 100 batch | 61.42%  |
| Ensemble promedio 3 best models - 64 batch | 62.93%  |
| Ensemble ponderado 2 best models - 64 batch | 64.71%  |
| Ensemble promedio 2 best models - 100 batch | 67.30%  |
| Modelo Paper 10 layers CNN + MaxPooling + Dropout   | 68.65% |
| Ensemble promedio 2 best models - 64 batch | 69.83%  |
| Modelo Paper 10 layers CNN + BatchNormalization + MaxPooling + Dropout   | 71.03%  |
| Keras Tunner 4 layers CNN + BatchNormalization + MaxPooling + Dropout - 64 batch | 71.32% |
| VGG19 + BatchNormalization   | 73.30% (presenta overfitting) | 
| Ensemble promedio 3 best models - 2 same model | 74.18%  |
| XceptionNet + BatchNormalization  | 74.64% (presenta overfitting)  |
| Keras Tunner 4 layers CNN + BatchNormalization + MaxPooling + Dropout - 128 batch |




| Modalidad texto  |  Accuracy |
| ------------- | ------------- |
| LSTM + Embedding Keras   | 14.38%  |
| BiLSTM + Embedding Word2Vec   | 49.71%  |
| BiLSTM + Embedding GloVe   | 55.45%  |
| BiLSTM + Embedding Keras   | 74.36%  |
| Paper BiLSTM + Embedding Word2Vec + FastText   | 51.78%  |
| Modelo Paper Bert + CNN 4 layers - 64 batch  | 76.55% |
| Modelo Paper Bert + CNN 4 layers - 16 batch  | 84.84% |
| BiLSTM + CNN(n-gram) + Embedding Keras   | 92.23%  |
| BiLSTM + CNN + Embedding Keras   | 94.16%  |
| Bert + BiLSTM  | 94.27% |
| Bert + CNN(n-gram)   | 97.87% |


División de datos: HoldOut
- 70% train, 10% test, 20% validation
- Para la modalidad facial y de texto se hizo uso de aplicación de generadores para ingresar los datos mediante batches

Archivo [GloVe](https://drive.google.com/file/d/1qFlDu71eLDMDoAyX21eWNkCY3Xntlzyn/view?usp=sharing)

Mejores modelos obtenidos:
- Texto: Bert + CNN(N-Gram)
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/6d5570ff-1c63-4e90-838f-192185cbbcf1)
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/4483eacf-23c3-4dfc-9d5b-1943566492b6)
  - Accuracy: 97.87%
  - F1-Score: 98%
  - Recall: 98%
  - Accuracy en conjunto de testeo: 98.15%
  - Batch_size = 64
  - Archivo [Bert+CNN](https://drive.google.com/file/d/1Y_PmcmaJUCgqj4VWx0A7wKHC_BkKH5yO/view?usp=sharing)

- Facial: Keras Tunner 4 layers CNN + BatchNormalization + MaxPooling + Dropout
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/59c9cd5e-6aac-41d0-8d8d-311f1aec758e)
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/e40d5b7b-db19-4671-9985-965e895a400b)
  - Accuracy: 80%
  - F1-Score: 79%
  - Recall: 79%
  - Accuracy en conjunto de testeo: 79.21%
  - Batch_size = 128
  - Archivo [KerasTunner4layersCNN](https://drive.google.com/file/d/1D727aWWQyUNx5pRVHMu6amRAGCa1a-UY/view?usp=sharing)

 
Modelo multimodal: [En desarrollo]

Sistema:
- Para el desarrollo del sistema se va hacer uso del framework Django para el Backend e implementación del modelo multimodal. Para el lado del Frontend se va hacer uso de React.
- El sistema recopilará la información de entrada facial y texto del estudiante al usar el sistema, lo cual, se entregará al modelo multimodal para obtener la emoción final que el estudiante obtuvo en cada pregunta de forma individual y total mediante el promedio.

Tabla de requerimientos: [En desarrollo]

Diagrama del sistema: ![Diagrama sistema](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/bf9153c4-5603-4861-a879-ea89985cc933)



