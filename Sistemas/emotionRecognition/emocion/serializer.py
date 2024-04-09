from rest_framework.serializers import ModelSerializer
from .models import Emocion

class SerializerEmocion(ModelSerializer):
    class Meta:
        model = Emocion
        fields = '__all__'
