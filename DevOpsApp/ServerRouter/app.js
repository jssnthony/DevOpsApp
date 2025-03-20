const express = require('express');
const { createProxyMiddleware } = require('http-proxy-middleware');

const app = express();

// ?? Primero, proxy para el API Gateway (7101)
app.use('/api', createProxyMiddleware({
    target: 'http://localhost:22770',
    changeOrigin: true,
    secure: false,
    pathRewrite: { '^/api': '' },  // Asegúrate de que la API lo espera sin "/api"
    logLevel: 'debug'
}));

// ?? Luego, proxy para el controlador (7153)
app.use('/controller', createProxyMiddleware({
    target: 'http://localhost:33996',
    changeOrigin: true,
    secure: false,
    pathRewrite: { '^/controller': '' },
    logLevel: 'debug'
}));

// ?? Por último, proxy para la UI (1337)
app.use('/', createProxyMiddleware({
    target: 'http://localhost:1337',
    changeOrigin: true
}));

app.listen(3000, () => {
    console.log('API Gateway corriendo en http://localhost:3000');
});
