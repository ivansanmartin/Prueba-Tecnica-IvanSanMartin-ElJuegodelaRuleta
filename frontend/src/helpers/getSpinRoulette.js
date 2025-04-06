import apiClient from "@/api/apiClient";

export const getSpinRoulette = async () => {
    const response = await apiClient.get("/spin-roulette");

    return response.data;
}



