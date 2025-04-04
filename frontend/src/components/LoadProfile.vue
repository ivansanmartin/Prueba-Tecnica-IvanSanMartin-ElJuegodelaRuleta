<template>
    <div class="load-profile-game mt-3 m-2 d-flex flex-column align-items-center gap">
        <button class="btn btn-success" data-bs-toggle="modal" data-bs-target="#loadProfileModal">Cargar mi
            perfil
        </button>

        <div class="modal fade" id="loadProfileModal" tabindex="-1" aria-labelledby="loadProfileModal"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="loadProfileLabel">Cargar mi perfil</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="input-group">
                                <span class="input-group-text"><i class="fa-solid fa-user-tie"></i></span>
                                <input type="text" name="username" id="username" class="form-control"
                                    placeholder="Ingrese su nombre de usuario (ejemplo: ivan)">
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-primary">Cargar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>