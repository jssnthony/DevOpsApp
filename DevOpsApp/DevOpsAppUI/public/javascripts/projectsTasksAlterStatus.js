window.alterStatus = async function (button) {
    const taskId = button.dataset.taskId;

    try {
        const response = await fetch(`/projectsTasks/alter-status/${taskId}`, {
            method: 'PUT',
        });

        if (response.ok) {
            button.textContent = button.textContent === 'Done' ? 'ToDo' : 'Done';
        } else {
            console.error('No se pudo cambiar el estado.');
        }
    } catch (error) {
        console.error('Error en la petición:', error);
    }
}
