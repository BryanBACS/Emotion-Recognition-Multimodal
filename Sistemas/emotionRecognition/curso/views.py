from django.shortcuts import render
from .serializer import CursoSerializer
from .models import Curso
from rest_framework.response import Response
from rest_framework import status
from docente.models import Docente
from rest_framework.decorators import api_view

# Create your views here.
@api_view(['POST'])
def createCurso(request):
    data = request.data
    if 'docente_id' in data:
        pkDocente = data['docente_id']
        try:
            docenteEncontrado = Docente.objects.get(pk=pkDocente)
        except Docente.DoesNotExist:
            return Response({'error': 'El docente no existe.'}, status=status.HTTP_400_BAD_REQUEST)
        data = {
            'nombre_curso': data['nombre_curso'],
            'Docente_asignado': docenteEncontrado
        }
        serializer = CursoSerializer(data =data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_201_CREATED)
        return Response(status=status.HTTP_400_BAD_REQUEST)
    else:
        serializer = CursoSerializer(data=data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_201_CREATED)
        return Response(status=status.HTTP_400_BAD_REQUEST)
    
@api_view(['GET'])
def getAllCursos(request):
    cursos = Curso.objects.all()
    serializer = CursoSerializer(cursos, many=True)
    return Response(serializer.data, status=status.HTTP_200_OK)

@api_view(['GET'])
def getCurso(request,pk):
    curso = Curso.objects.get(pk=pk)
    serializer = CursoSerializer(curso)
    return Response(serializer, status=status.HTTP_200_OK)

@api_view(['PUT'])
def updateCursos(request,pk):
    curso = Curso.objects.get(pk=pk)
    data = request.data
    serializer = CursoSerializer(curso,data=data)
    return Response(serializer.data, status=status.HTTP_200_OK)


@api_view(['DELETE'])
def deleteCursos(request,pk):
    curso = Curso.objects.get(pk=pk)
    curso.delete()
    return Response(status=status.HTTP_204_NO_CONTENT)

