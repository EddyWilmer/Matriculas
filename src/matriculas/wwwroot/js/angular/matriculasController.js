﻿// matriculasController.js

(function () {
    "use strict";
    // Llama al módulo prinicipal e incluye el controlador
    angular.module("app")
        .controller("matriculasController", matriculasController);

    // Interactua con la Api matriculasController.cs
    function matriculasController($http) {
        var vm = this;
        vm.matriculas = [];
        vm.grados = [];
        vm.isBusy = true;
        vm.enablePdf = false;

        // Pagination
        vm.pageSize = 10;
        vm.actualCount; // Cantidad actual de alumnos

        vm.newMatricula = { alumno: { apoderado: {} }, grado: {} };
        vm.currentAlumnoDni;
        vm.currentDni;
        vm.currentGrado;

        $http.get("/api/v2/matriculas")
            .then(function (response) {
                // Success   
                angular.copy(response.data, vm.matriculas);
            }, function (error) {
                // Failure
                vm.errorMessage = "No se pudo cargar las matrículas.";
            })
            .finally(function () {
                vm.isBusy = false;
            });

        // Solicita la lista de grados Disponibles (Los que están en estado 1)
        $http.get("/api/v2/grados")
            .then(function (response) {
                // Success
                angular.copy(response.data, vm.grados);
            }, function (error) {
                // Failure
                vm.errorMessage = "No se pudo cargar la información de grados.";
            });


        // Recupera los datos del alumno
        vm.addMatricula = function () {
            vm.isBusy = true;
            vm.errors = [];

            $http.post("/api/v2/matriculas", vm.newMatricula)
                .then(function (response) {
                    // Success   
                    vm.matriculas.push(response.data);
                    vm.currentAlumnoDni = response.data.alumno.dni;

                    toastr.success("Se matriculó al alumno correctamente.");

                    vm.enablePdf = true;
                }, function (error) {
                    // Failure
                    angular.copy(error.data, vm.errors);

                    if (typeof vm.errors.noDisponible !== "undefined")
                        toastr.warning(vm.errors.noDisponible);

                    if (typeof vm.errors.yaMatriculado !== "undefined")
                        toastr.warning(vm.errors.yaMatriculado);

                    toastr.error("No se pudo registrar la matricula.");
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        }

        // Recupera el grado del alumno
        vm.getGrado = function (id) {
            vm.isBusy = true;
            
            $http.get("/api/v2/alumnos/" + id + "/grado")
                .then(function (response) {
                    // Success   
                    vm.currentGrado = response.data.nombre + " de " + response.data.nivel.nombre;
                    vm.getNextGrado(vm.newMatricula.alumno.id);
                }, function (error) {
                    // Failure
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        }

        // Recupera el grado del alumno
        vm.getNextGrado = function (id) {
            vm.isBusy = true;

            $http.get("/api/v2/alumnos/" + id + "/nextGrado")
                .then(function (response) {
                    // Success   
                    angular.copy(response.data, vm.newMatricula.grado);
                }, function (error) {
                    // Failure
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        }

        //Recupera los datos del alumno
        vm.getAlumno = function (dni) {
            vm.isBusy = true;
            vm.reset();
            
            $http.get("/api/v2/alumnos/dni/" + dni)
            .then(function (response) {
                // Success                
                angular.copy(response.data, vm.newMatricula.alumno);
                vm.newMatricula.alumno.fechaNacimiento = new Date(vm.newMatricula.alumno.fechaNacimiento);
                vm.getGrado(vm.newMatricula.alumno.id);           
            }, function (error) {
                // Failure
                vm.errorMessage = "No se pudo cargar la información del alumno.";
            })
            .finally(function () {
                vm.isBusy = false;             
            });
        }

        vm.reset = function () {
            vm.newMatricula = { alumno: { apoderado: {} }, grado: {} };
            vm.currentGrado = null;         
        }
    }
})();