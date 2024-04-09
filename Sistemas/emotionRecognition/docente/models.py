from django.db import models
from django.contrib.auth.models import AbstractBaseUser,UserManager
from django.utils import timezone


# Create your models here.

class CustomUserManager(UserManager):
    def create_user(self, rut, email=None, password=None, **extra_fields):
        if not rut:
            raise ValueError('El RUT es obligatorio.')

        email = self.normalize_email(email)
        user = self.model(rut=rut, email=email, **extra_fields)
        user.set_password(password)
        user.save(using=self._db)
        return user

    def create_superuser(self, rut, email, password=None, **extra_fields):
        extra_fields.setdefault('is_staff', True)
    
        return self.create_user(rut, email, password, **extra_fields)


class Docente(AbstractBaseUser):
    rut = models.CharField(max_length=255, unique=True)
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255, unique=True)
    password = models.CharField(max_length=255)

    is_staff = models.BooleanField(default=False)
    is_active = models.BooleanField(default= True)
    date_joined = models.DateTimeField(default=timezone.now)

    USERNAME_FIELD = "rut"
    REQUIRED_FIELDS = ["email"]

    objects = CustomUserManager()

    #Esto es para poder visualizar el admin con un customUser.
    def has_perm(self, perm, obj=None):
        return self.is_staff
    def has_module_perms(self, app_label):
        return self.is_staff

    def __str__(self):
        return self.rut
        

