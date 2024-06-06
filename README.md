# Emotion-Recognition-Multimodal

Autores: BRYAN CABEZAS, PABLO SCHWARZENBERG

Código para la tesis que tiene como objetivo desarrollar un sistema que implemente modelos multimodales para el reconocimiento de emociones mediante la modalidad facial y de texto. El propósito del modelo y sistema es proporcionar retroalimentación en tiempo real al docente y permitirle ajustar sus estrategias pedagógicas de acuerdo a las emociones detectadas en los estudiantes.

<!--
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
| Keras Tunner 4 layers CNN + BatchNormalization + MaxPooling + Dropout - 128 batch | 77%
| Ensamble Keras Tunner 4 layers CNN +  Modelo Paper 10 layers CNN + Keras tunner 300 epochs - 128 batch | 80% |





| Modalidad texto  |  Accuracy |
| ------------- | ------------- |
| Embedding Word2Vec + BiLSTM   | 67%  |
| Embedding GloVe + CNN   | 69%  |
| Bert + CNN(n-gram) - 5 emotions  | 78% |
| RoBERTa + CNN(n-gram) - 5 emotions  | 79% |
| RoBERTa + CNN(n-gram) - 7 emotions  | 81% |


División de datos: HoldOut
- 70% train, 10% test, 20% validation
- Para la modalidad facial y de texto se hizo uso de aplicación de generadores para ingresar los datos mediante batches

Mejores modelos obtenidos:
- Texto: Bert + CNN(N-Gram)
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/76d1e06c-634e-4bbf-bee7-8e982e899250)
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/a97c2c28-25c3-42f7-8695-a8e16cf05fe1)
  - Accuracy: 81%
  - F1-Score: 80%
  - Recall: 80%


- Facial: Ensamble Keras Tunner +  Modelo Paper 10 layers CNN + Keras tunner 300 epochs
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/3ed61ba9-c3c4-4794-807c-b1bc03138074)
  ![image](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/218df3c6-04bd-40c2-8a1f-8b63ca3445ee)
  - Accuracy: 80%
  - F1-Score: 79%
  - Recall: 79%


 
Modelo multimodal: [En desarrollo]

Sistema:
- Para el desarrollo del sistema se va hacer uso del framework Django para el Backend e implementación del modelo multimodal. Para el lado del Frontend se va hacer uso de React.
- El sistema recopilará la información de entrada facial y texto del estudiante al usar el sistema, lo cual, se entregará al modelo multimodal para obtener la emoción final que el estudiante obtuvo en cada pregunta de forma individual y total mediante el promedio.

Tabla de requerimientos: [En desarrollo]

Diagrama del sistema: ![Diagrama sistema](https://github.com/BryanBACS/Emotion-Recognition-Multimodal/assets/124418262/bf9153c4-5603-4861-a879-ea89985cc933) -->



