import axios from "axios";

const API_ENDPOINT = "http://localhost:5138/api/users";

export const updateUser = async (body) => {
	try {
		const response = await axios.put(API_ENDPOINT, body, {
            headers: {
                "Content-Type": "application/json"
            }
        });
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
