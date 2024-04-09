from django.urls import path
from emocion.views import createEmocion,getallEmocion,updateEmocion,deleteEmocion,getEmocion

urlpatterns = [
    path('create/', createEmocion),
    path('getAll/', getallEmocion),
    path('getEmocion/<int:pk>/', getEmocion),
    path('delete/<int:pk>/', deleteEmocion),
    path('update/<int:pk>/', updateEmocion)
]
