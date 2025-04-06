import apiClient from "@/api/apiClient";

export const getUserProfile = async (username) => {
	try {
		const response = await apiClient.get(`/users/${username}`);
		return response.data;
	} catch (error) {
		if (error.response && error.response.status === 404) {
			return error.response.data;
		} else {
			return {
				ok: false,
				message: "An unexpected error occurred",
				message_code: "UNKNOWN_ERROR",
			};
		}
	}
};
