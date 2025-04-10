'use strict';
var express = require('express');
var router = express.Router();

process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0'; // Deshabilitar validación SSL

// Ruta para mostrar el formulario de edición
router.get('/:id', async function (req, res) {
    try {
        const API_URL_PROJECTS_TASKS = req.app.locals.config.API_URL_PROJECTS_TASKS;
        const taskId = req.params.id;

        // Obtener los datos del proyecto
        const response = await fetch(`${API_URL_PROJECTS_TASKS}/${taskId}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error(`Error al obtener la tarea: ${response.statusText}`);
        }

        const task = await response.json();
        res.render('projectsTasksUpdate', { title: 'Editar Tarea', task });
    } catch (error) {
        console.error('Error al obtener la tarea:', error);
        res.status(500).send('Error al obtener la tarea');
    }
});

// Ruta para actualizar la tarea
router.post('/:id', async function (req, res) {
    try {
        const { title, description } = req.body;
        const taskId = req.params.id;
        const API_URL_PROJECTS_TASKS = req.app.locals.config.API_URL_PROJECTS_TASKS;
        const body = JSON.stringify({
            id: taskId,
            title,
            description
        });
        const response = await fetch(`${API_URL_PROJECTS_TASKS}/Update/${taskId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: body
        });

        if (!response.ok) {
            throw new Error(`Error al actualizar la tarea: ${response.statusText}`);
        }
        
        const task = await response.json();
        res.redirect('/projectsTasks/' + task.projectId);

    } catch (error) {
        console.error('Error al actualizar la tarea:', error);
        res.status(500).send('Error al actualizar la tarea');
    }
});

module.exports = router;
