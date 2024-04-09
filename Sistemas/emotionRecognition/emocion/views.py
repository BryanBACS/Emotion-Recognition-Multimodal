from django.shortcuts import render
from rest_framework.decorators import api_view
from .models import Emocion
from pregunta.models import Pregunta
from alumno.models import Alumno
from .serializer import SerializerEmocion
from rest_framework.response import Response
from rest_framework import status
from django.http import Http404

# Create your views here.
@api_view(['GET'])
def getallEmocion(request):
    emociones = Emocion.objects.all()
    serializer = SerializerEmocion(emociones, many=True)
    return Response(serializer.data, status=status.HTTP_200_OK)

@api_view(['GET'])
def getEmocion(request,pk):
    emocion = Emocion.objects.get(pk=pk)
    serializer = SerializerEmocion(emocion)
    return Response(serializer.data, status=status.HTTP_200_OK)

@api_view(['POST'])
def createEmocion(request):
    data = request.data
    #Modelo predecir
    emocionTexto= "Happy"
    EmocionImagen="Happy"
    emocion="Happy"
    alumno_id = data['alumno_id']
    pregunta_id = data['pregunta_id']
    respuesta = data['respuesta']
    try:
        pregunta = Pregunta.objects.get(pk=pregunta_id)
        alumno = Alumno.objects.get(pk=alumno_id)
    except (Pregunta.DoesNotExist, Alumno.DoesNotExist):
        raise Http404("Alumno o pregunta no encontrados")  # Manejo del error
    data = {
        'alumno':alumno,
        'pregunta':pregunta,
        'respuesta': respuesta,
        'emocionTexto':emocionTexto,
        'EmocionImagen': EmocionImagen,
        'emocion':emocion
    }
    serializer= SerializerEmocion(data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(status=status.HTTP_400_BAD_REQUEST)


@api_view(['PUT'])
def updateEmocion(request,pk):
    emocion = Emocion.objects.get(pk=pk)
    data = request.data
    serializer = SerializerEmocion(emocion, data=data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_200_OK)
    return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)



@api_view(['DELETE'])
def deleteEmocion(request,pk):
    emocion = Emocion.objects.get(pk=pk)
    emocion.delete()
    return Response(status=status.HTTP_204_NO_CONTENT)



