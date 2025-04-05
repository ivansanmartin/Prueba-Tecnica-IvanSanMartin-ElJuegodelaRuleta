import { updateOrCreateUser } from "@/helpers/updateOrCreateUser";

export const useUpdateOrCreateUser = async (body) => {
    const gameResult = await updateOrCreateUser(body);

    return gameResult;
}