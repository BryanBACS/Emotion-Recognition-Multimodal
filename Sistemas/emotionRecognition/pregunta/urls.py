from django.urls import path
from pregunta.views import createPregunta,getAllPregunta,DeletePregunta,UpdatePregunta,getPregunta

urlpatterns = [
    path('createPregunta/', createPregunta),
    path('getAllPreguntas/', getAllPregunta),
    path('getPregunta/<int:pk>/', getPregunta),
    path('deletePregunta/<int:pk>/', DeletePregunta),
    path('updatePregunta/<int:pk>/', UpdatePregunta)
]
