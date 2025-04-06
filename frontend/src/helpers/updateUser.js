import apiClient from "@/api/apiClient";

export const updateUser = async (body) => {
	try {
		const response = await apiClient.put("/users", body);
		return response.data;
	} catch (error) {
		if (error.response?.status === 404) {
			return error.response.data;
		}
		return {
			ok: false,
			message: "An unexpected error occurred",
			message_code: "UNKNOWN_ERROR",
		};
	}
};