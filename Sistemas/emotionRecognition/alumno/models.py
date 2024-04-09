from django.db import models
from docente.models import Docente

# Create your models here.
class Alumno(models.Model):
    first_name = models.CharField(max_length=255)
    last_name= models.CharField(max_length=255)
    edad = models.IntegerField()

    def __str__(self):
        return self.first_name

