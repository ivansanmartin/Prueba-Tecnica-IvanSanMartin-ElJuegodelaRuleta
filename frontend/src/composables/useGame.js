import { useGameResultStore } from "@/store/user/gameResultStore";
import { getGameResult } from "@/helpers/getGameResult";

export const useGame = async (body) => {
    const gameResult = await getGameResult(body);
    const gameResultStore = useGameResultStore();

    gameResultStore.loadGameResult(gameResult);

    return gameResult;
}