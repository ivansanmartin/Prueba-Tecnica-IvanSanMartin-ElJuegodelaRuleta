<template>
    <div class="option-number-and-color d-flex flex-column">
        <div class="input-group mt-4">
            <span class="input-group-text"><span><small>🔴</small></span>|<span><small>⚫</small></span></span>
            <select name="color" id="color" class="form-select">
                <option selected>Seleccione algún color</option>
                <option value="rojo">Rojo</option>
                <option value="negro">Negro</option>
            </select>
        </div>

        <div class="mt-3">
            <input type="text" name="numerBet" id="numerBet" class="form-control" placeholder="Ingrese un número">
        </div>
    </div>

    <div class="spin-button">
      <button class="btn btn-secondary mt-5" @click="">Apostar</button>
    </div>
</template>