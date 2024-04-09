from django.db import models
from alumno.models import Alumno
from pregunta.models import Pregunta


# Create your models here.
class Emocion(models.Model):
    alumno = models.ForeignKey(Alumno, on_delete=models.CASCADE)
    pregunta = models.ForeignKey(Pregunta, on_delete=models.CASCADE)
    respuesta = models.CharField(max_length=255)
    emocionTexto = models.CharField(max_length=100)
    emocionImagen = models.CharField(max_length=100)
    emocion = models.CharField(max_length=100)

    def __str__(self):
        return self.respuesta

