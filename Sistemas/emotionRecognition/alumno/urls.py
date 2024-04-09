from django.urls import path
from alumno.views import createAlumno, getAllAlumno, DeleteAlumno,getAlumno

urlpatterns = [
    path('create/', createAlumno),
    path('getAll/', getAllAlumno),
    path('getAlumno/<int:pk>', getAlumno),
    path('delete/<int:pk>', DeleteAlumno),
]
