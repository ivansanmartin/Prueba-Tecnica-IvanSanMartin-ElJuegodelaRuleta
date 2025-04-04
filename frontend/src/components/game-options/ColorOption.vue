<template>
    <div class="option-color">
        <div class="input-group mt-4">
            <span class="input-group-text"><span><small>🔴</small></span>|<span><small>⚫</small></span></span>
            <select name="color" id="color" class="form-select">
                <option selected>Seleccione algún color</option>
                <option value="rojo">Rojo</option>
                <option value="negro">Negro</option>
            </select>
        </div>
    </div>

    <div class="spin-button">
      <button class="btn btn-secondary mt-5" @click="">Apostar</button>
    </div>


</template>