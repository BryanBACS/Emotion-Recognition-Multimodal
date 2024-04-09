from django.urls import path
from docente.views import createDocente,getAllDocentes,UpdateDocentes,DeleteDocentes,getDocente

urlpatterns = [
    path('create/', createDocente),
    path('getAll/', getAllDocentes),
    path('getDocente/<int:pk>/', getDocente),
    path('delete/<int:pk>/', DeleteDocentes),
    path('update/<int:pk>/', UpdateDocentes)
]
