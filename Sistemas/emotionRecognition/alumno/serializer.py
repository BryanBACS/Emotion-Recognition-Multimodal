from rest_framework.serializers import ModelSerializer
from .models import Alumno

class SerializerAlumno(ModelSerializer):
    class Meta:
        model = Alumno
        fields = '__all__'
