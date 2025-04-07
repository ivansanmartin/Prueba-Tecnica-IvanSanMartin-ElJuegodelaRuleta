<template>
	<div v-if="loadingStore.isLoading" class="loading mt-5">
		<div class="spinner-border text-danger" role="status"></div>
		<div>
			<p>Girando ruleta...</p>
		</div>
	</div>
</template>

<script setup>
import { useLoadingStore } from "@/store/game/loadingStore";

const loadingStore = useLoadingStore();
</script>
