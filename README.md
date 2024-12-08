# Emotion-Recognition-Multimodal

Autores: BRYAN CABEZAS, PABLO SCHWARZENBERG

Este repositorio contiene el código desarrollado para la tesis cuyo objetivo es crear modelos unimodales faciales y textuales innovadores para el reconocimiento de emociones en el ámbito educativo, con el propósito de ofrecer modelos robustos y precisos, aplicables en sistemas educativos, facilitando la retroalimentación y comprensión de emociones, y estableciendo las bases para una futura integración multimodal.

Los modelos se encuentran almacenados en la carpeta "Modelos inteligencia artificial". Para la modalidad facial, se incluyen cuatro códigos: dos que implementan modelos individuales, cada uno utilizando un método distinto de balanceo de datos, y dos con nombres "Ensemble", que presentan modelos ensemble desarrollados a partir de la combinación de diferentes arquitecturas. Entre estos, destaca el archivo "2_codeEnsembleWithWeights.ipynb" como el más relevante. En cuanto a la modalidad textual, se incluye únicamente el archivo "code.ipynb", el cual utiliza los archivos CSV generados directamente dentro del mismo código.

Para la modalidad facial, se propuso una metodología que combina dos datasets ampliamente utilizados en el reconocimiento de emociones: FER2013 y CK+48. Esta combinación se complementó con dos enfoques de balanceo de datos: el uso de pesos ponderados para ajustar la importancia de las clases en función de su representación en el dataset, y la generación de datos sintéticos mediante técnicas de Data Augmentation, lo que permitió equilibrar las clases. El modelo desarrollado para esta modalidad es un Ensemble, diseñado para mejorar la generalización del reconocimiento.
![MetodologiaFacial3](https://github.com/user-attachments/assets/0c25c728-8492-44f5-bb85-2ecff14e22ff)

En cuanto a la modalidad textual, se desarrollaron dos metodologías basadas en emociones comúnmente experimentadas en el ámbito educativo. La primera se centra en un conjunto de 5 emociones principales presentes en contextos educativos, mientras que la segunda amplía este conjunto al incorporar 2 emociones adicionales: "Surprise" y "Neutral", las cuales representan estados emocionales observados en estudiantes y respaldados por literatura científica relevante. Para el conjunto de entrenamiento, se aplicaron técnicas de aumento de datos para enriquecer su diversidad y una limpieza exhaustiva para garantizar su calidad. Posteriormente, estos datos fueron transformados mediante el uso de embeddings y modelos preentrenados, destacándose RoBERTa con una arquitectura N-Gram, que permitió capturar características clave para el reconocimiento de emociones.
![MetodologiaTextual](https://github.com/user-attachments/assets/e80f01e3-b491-4233-a8b6-2a41a7f8cb55)


- Resultados modalidad facial:
| Model FER2013                           | Accuracy | Precision | Recall | F1-Score |
|-----------------------------------------|------------------|-----------|--------|----------|
| Model1ensemblewithCNN-1, VGG19, CNN-6 (weight balancing) | 68.15%           | 67%       | 67%    | 66%      |
| Model2ensemblewithCNN-1, CNN-2, VGG19 (data balancing)    | 69.61%           | 71%       | 67%    | 68%      |
| Model3ensemblewithCNN-1, CNN-2 (first augmentation), CNN-2 (second augmentation) (weight balancing) and CNN-1, VGG19 (data balancing) | 69.94%           | 69%       | 68%    | 68%      |
| Model4ensemblewithCNN-1, CNN-2 (first augmentation), CNN-2 (second augmentation) (weight balancing) and CNN-1, CNN-2, VGG19 (data balancing) | 70.20%           | 70%       | 68%    | 69%      |



- Resultados modalidad textual:





