import { useSpinRouletteStore } from "@/store/spinRouletteStore";
import { getSpinRoulette } from "@/helpers/getSpinRoulette";

export const useRoulette = async () => {
	const spin = await getSpinRoulette();
	const spinRoulleteStore = useSpinRouletteStore();

	spinRoulleteStore.roulette = spin;
	return spin;
};
