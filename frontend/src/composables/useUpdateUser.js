import { updateUser } from "@/helpers/updateUser";

export const useUpdateUser = async (body) => {
    const gameResult = await updateUser(body);

    return gameResult;
}