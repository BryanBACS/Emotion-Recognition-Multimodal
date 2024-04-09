from django.urls import path
from curso.views import createCurso, getAllCursos, getCurso, deleteCursos, updateCursos

urlpatterns = [
    path('create/', createCurso),
    path('getAll/', getAllCursos),
    path('getCurso/<int:pk>/', getCurso),
    path('delete/<int:pk>/', deleteCursos),
    path('update/<int:pk>/', updateCursos)
]
