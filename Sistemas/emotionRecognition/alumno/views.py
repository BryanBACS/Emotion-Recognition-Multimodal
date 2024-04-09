from django.shortcuts import render
from rest_framework.decorators import api_view, permission_classes
from rest_framework.response import Response
from .models import Alumno
from .serializer import SerializerAlumno
from rest_framework import status


# Create your views here.
@api_view(['POST'])
def createAlumno(request):
    data = request.data
    serializer = SerializerAlumno(data=data)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data, status=status.HTTP_201_CREATED)
    return Response(status=status.HTTP_400_BAD_REQUEST)


@api_view(['GET'])
def getAllAlumno(request):
    alumnos = Alumno.objects.all()
    serializer = SerializerAlumno(alumnos, many=True)
    return Response(serializer.data, status=status.HTTP_200_OK)

@api_view(['GET'])
def getAlumno(request,pk):
    alumno = Alumno.objects.get(pk=pk)
    serializer = SerializerAlumno(alumno)
    return Response(serializer.data, status=status.HTTP_200_OK)


@api_view(['DELETE'])
def DeleteAlumno(request, pk):
    alumno = Alumno.objects.get(pk=pk)
    alumno.delete()
    return Response(status=status.HTTP_200_OK)

