import { AppState } from "../AppState"
import { Vault } from "../models/Vault"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
const MDI = 'account'
class VaultsService{
    async getVaultsByAccountId(){
        const res = await api.get(MDI + '/vaults')
        AppState.vaults = res.data.map(v=> new Vault(v))
        logger.log(AppState.vaults)
    }
}

export const vaultsService = new VaultsService()