'use strict';
var express = require('express');
var router = express.Router();

process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0'; // Deshabilitar validación SSL

// Ruta para archivar un proyecto
router.post('/:id', async function (req, res) {
    try {
        const projectId = req.params.id;
        const API_URL_PROJECTS = req.app.locals.config.API_URL_PROJECTS;

        const response = await fetch(`${API_URL_PROJECTS}/Archive/${projectId}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error al archivar el proyecto: ${errorText}`);
        }

        res.redirect('/projects');
    } catch (error) {
        console.error('Error al archivar proyecto:', error);
        res.status(500).send('Error al archivar proyecto');
    }
});

module.exports = router;
