import { getUserProfile } from "@/helpers/getUserProfile";
import { useProfileStore } from "@/store/profileStore";

export const useUser = async (username) => {
	const profile = await getUserProfile(username);
	const profileStore = useProfileStore();
    
	profileStore.loadProfile(profile);
	return profile;
};
