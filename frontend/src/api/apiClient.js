import axios from "axios";
import axiosRetry from "axios-retry";

const apiClient = axios.create({
	baseURL: "https://roulette.ivansanmartin.dev/api",
	headers: {
		"Content-Type": "application/json",
	},
});

axiosRetry(apiClient, {
	retries: 3,
	retryDelay: axiosRetry.exponentialDelay,
	retryCondition: (error) => {
		return axiosRetry.isNetworkOrIdempotentRequestError(error) || error.code === 'ECONNABORTED';
	},
});

export default apiClient;