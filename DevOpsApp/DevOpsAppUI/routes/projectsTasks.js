'use strict';
var express = require('express');
var router = express.Router();
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0'; // ignorar SSL si es necesario

// Ver tareas de un proyecto
router.get('/:projectId', async function (req, res) {
    const projectId = req.params.projectId;
    const API_URL = req.app.locals.config.API_URL_PROJECTS_TASKS;

    try {
        const response = await fetch(`${API_URL}/GetAll/${projectId}`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        });

        if (!response.ok) throw new Error(`Error al obtener tareas: ${response.statusText}`);

        const tasks = await response.json();
        console.log(tasks);
        res.render('projectsTasks', { title: 'Tareas', tasks, projectId });
    } catch (error) {
        console.error('Error:', error);
        res.status(500).send('Error al obtener tareas');
    }
});

router.put('/alter-status/:taskId', async function (req, res) {
    const taskId = req.params.taskId;
    const API_URL = req.app.locals.config.API_URL_PROJECTS_TASKS;
    const alterStatusUrl = `${API_URL}/AlterStatus/${taskId}`;

    try {
        const response = await fetch(alterStatusUrl, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' }
        });

        if (!response.ok) throw new Error(`Error al actualizar estado: ${response.statusText}`);

        const updatedTask = await response.json();
        res.status(200).json(updatedTask);
    } catch (error) {
        console.error('Error actualizando estado:', error);
        res.status(500).json({ error: 'No se pudo cambiar el estado' });
    }
});


module.exports = router;
