from django.shortcuts import render
from rest_framework.decorators import api_view, permission_classes
from rest_framework.permissions import IsAuthenticated
from rest_framework.response import Response
from django.contrib.auth.hashers import make_password
from .models import Docente
from .serializer import SerializerDocente
from rest_framework import status


# Create your views here.
@api_view(['POST'])
#@permission_classes([IsAuthenticated])  # policy decorator
def createDocente(request):
    data = request.data

    data={
        'rut': data['rut'],
        'first_name': data['first_name'],
        'last_name': data['last_name'],
        'email': data['email'],
        'password': make_password(data['password']), #la encripta # Utilizar la contraseña encriptada
    }
    serializer = SerializerDocente(data=data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(status=status.HTTP_400_BAD_REQUEST)


@api_view(['GET'])
def getAllDocentes(request):
    docentes = Docente.objects.all()
    serializer = SerializerDocente(docentes, many=True)
    return Response(serializer.data, status=status.HTTP_200_OK)

@api_view(['GET'])
def getDocente(request,pk):
    docente = Docente.objects.get(pk=pk)
    serializer = SerializerDocente(docente)
    return Response(serializer.data, status=status.HTTP_200_OK)

@api_view(['PUT'])
def UpdateDocentes(request, pk):
    data = request.data()
    docente = Docente.objects.get(pk=pk)
    if data.password != docente.password:
        make_password(data.password)
    serializer = SerializerDocente(docente, data=data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_200_OK)
    return Response(status=status.HTTP_400_BAD_REQUEST)

@api_view(['DELETE'])
def DeleteDocentes(request, pk):
    docente = Docente.objects.get(pk=pk)
    docente.delete()
    return Response(status=status.HTTP_200_OK)

