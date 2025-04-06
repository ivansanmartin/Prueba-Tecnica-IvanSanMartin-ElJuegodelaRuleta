<template>
    <div v-if="result && !loading" class="alert alert-secondary mt-4">
        <div class="title">
            <h6 class="badge text-bg-secondary">{{ result.message }}</h6>
        </div>
        <div class="results-roulette d-flex flex-column mt-3">
            <div class="d-flex flex-column align-items-center">
                <p>
                    <small :class="[
                        result.is_winner ? 'text-success' : 'text-danger',
                        'fw-bold'
                    ]">
                        {{ result.is_winner ? '¡Excelente!' : '¡Sigue intentándolo!' }}
                    </small>
                </p>
            </div>
        </div>
    </div>
</template>

<script setup>
defineProps({
    result: {
        type: Object,
        required: true,
    },
    loading: {
        type: Boolean,
        required: true,
    }
})

</script>