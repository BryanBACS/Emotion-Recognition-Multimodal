from rest_framework.serializers import ModelSerializer
from .models import Docente


class SerializerDocente(ModelSerializer):
    class Meta:
        model = Docente
        fields = ['id', 'rut', 'email', 'first_name', 'last_name', 'email', 'password','date_joined','is_active', 'is_staff']


        