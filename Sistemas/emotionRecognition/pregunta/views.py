from django.shortcuts import render
from rest_framework.decorators import api_view, permission_classes
from rest_framework.response import Response
from django.contrib.auth.hashers import make_password
from .models import Pregunta
from .serializer import SerializerPregunta
from rest_framework import status


# Create your views here.
@api_view(['POST'])
def createPregunta(request):
    data = request.data
    serializer = SerializerPregunta(data=data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(status=status.HTTP_400_BAD_REQUEST)


@api_view(['GET'])
def getAllPregunta(request):
    preguntas = Pregunta.objects.all()
    serializer = SerializerPregunta(preguntas, many=True)
    return Response(serializer.data, status=status.HTTP_200_OK)

@api_view(['GET'])
def getPregunta(request,pk):
    pregunta = Pregunta.objects.get(pk=pk)
    serializer = SerializerPregunta(pregunta)
    return Response(serializer.data, status=status.HTTP_200_OK)

@api_view(['PUT'])
def UpdatePregunta(request, pk):
    data = request.data()
    pregunta = Pregunta.objects.get(pk=pk)
    serializer = SerializerPregunta(pregunta, data=data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_200_OK)
    return Response(status=status.HTTP_400_BAD_REQUEST)

@api_view(['DELETE'])
def DeletePregunta(request, pk):
    pregunta = Pregunta.objects.get(pk=pk)
    pregunta.delete()
    return Response(status=status.HTTP_200_OK)


