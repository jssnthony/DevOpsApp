'use strict';
var express = require('express');
var router = express.Router();

process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0'; // Deshabilitar validación SSL


router.get('/', function (req, res) {
    res.render('projectsInsert', { title: 'Insert New Project' });
});

router.post('/', async function (req, res) {
    try {
        const { name, description, repository } = req.body;

        const API_URL_PROJECTS = req.app.locals.config.API_URL_PROJECTS; 
        
        const response = await fetch(`${API_URL_PROJECTS}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name,
                description,
                repository
            })
        });

        if (!response.ok) {
            throw new Error(`Error en la inserción: ${response.statusText}`);
        }

        res.redirect('/projects');
    } catch (error) {
        console.error('Error al insertar proyecto:', error);
        res.status(500).send('Error al insertar proyecto');
    }
});

module.exports = router;
