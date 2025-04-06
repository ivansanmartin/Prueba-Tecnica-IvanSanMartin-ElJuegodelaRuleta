import axios from "axios";

const API_ENDPOINT = "https://roulette.ivansanmartin.dev/api/spin-roulette";

export const getSpinRoulette = async () => {
    const response = await axios.get(API_ENDPOINT);

    return response.data;
}



