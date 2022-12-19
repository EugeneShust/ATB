const { ethers } = require("ethers");
const { getContractAt } = require("@nomiclabs/hardhat-ethers/internal/helpers");


// Helper method for fetching environment variables from .env
function getEnvVariable(key, defaultValue) {
    if (process.env[key]) {
        console.log("var1:", process.env[key]);
        return process.env[key];
    }
    if (!defaultValue) {
        throw `${key} is not defined and no default value was provided`;
    }
    console.log("var2:", defaultValue);
    return defaultValue;
}

// Helper method for fetching a connection provider to the Ethereum network
function getProvider() {
    if (getEnvVariable("NETWORK") == "localhost")
        return ethers.getDefaultProvider("http://127.0.0.1:8545/");
          
    return ethers.getDefaultProvider(getEnvVariable("NETWORK"), 
        {
            alchemy: getEnvVariable("ALCHEMY_KEY"),
        }
    );
}

// Helper method for fetching a wallet account using an environment variable for the PK
function getAccount() {
    return new ethers.Wallet(getEnvVariable("ACCOUNT_PRIVATE_KEY"), getProvider());
}

// Helper method for fetching a contract instance at a given address
function getContract(contractName, hre) {
    const account = getAccount();
    return getContractAt(hre, contractName, getEnvVariable("NFT_CONTRACT_ADDRESS", "0x63E7f84937455A2Cb74146d99aCb4731288335C4"), account);
}

module.exports = {
    getEnvVariable,
    getProvider,
    getAccount,
    getContract,
}