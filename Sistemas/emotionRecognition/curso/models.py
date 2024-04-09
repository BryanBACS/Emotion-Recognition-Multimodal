from django.db import models
from docente.models import Docente

# Create your models here.
class Curso(models.Model):
    nombre_curso = models.CharField(max_length=255)
    Docente_asignado = models.ForeignKey(Docente, on_delete=models.CASCADE, default=None, null=True)

    def __str__(self):
        return self.nombre_curso

