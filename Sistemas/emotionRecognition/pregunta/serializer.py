from rest_framework.serializers import ModelSerializer
from .models import Pregunta

class SerializerPregunta(ModelSerializer):
    class Meta:
        model = Pregunta
        fields = '__all__'