from django.db import models

# Create your models here.
class Pregunta(models.Model):
    numero_pregunta = models.IntegerField()
    enunciado_pregunta = models.CharField(max_length=255)
    puntos_pregunta = models.IntegerField()

    def __str__(self):
        return self.enunciado_pregunta

