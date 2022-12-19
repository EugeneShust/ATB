/**
* @type import('hardhat/config').HardhatUserConfig
*/

require('dotenv').config();
require("@nomiclabs/hardhat-ethers");
require("./scripts/deploy.js");
require("./scripts/mint.js");

const { ALCHEMY_KEY, ACCOUNT_PRIVATE_KEY } = process.env;

module.exports = {
   solidity: "0.8.17",
   defaultNetwork: "goerli",
   networks: {
    hardhat: {},
    localhost: {
      url: "http://127.0.0.1:8545/",
      chainId: 31337,
      accounts: [`0x${ACCOUNT_PRIVATE_KEY}`]
    },
    goerli: {
      url: `https://eth-goerli.alchemyapi.io/v2/${ALCHEMY_KEY}`,
      accounts: [`0x${ACCOUNT_PRIVATE_KEY}`]
    },
    ethereum: {
      chainId: 1,
      url: `https://eth-mainnet.alchemyapi.io/v2/${ALCHEMY_KEY}`,
      accounts: [`0x${ACCOUNT_PRIVATE_KEY}`]
    },
  },
}