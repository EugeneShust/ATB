const { task } = require("hardhat/config");
const { getContract } = require("./helpers");

task("mint", "Mints from the NFT contract")
.addParam("to", "_to")
.addParam("genes", "_genes")
.addParam("charge", "_charge")
.setAction(async function (taskArguments, hre) {
    const contract = await getContract("GameToken", hre);
    const transactionResponse = await contract.mint(taskArguments.to, taskArguments.genes, taskArguments.charge, {
        gasLimit: 500_000,
    });
    console.log(`Transaction Hash: ${transactionResponse.hash}`);
});

//mint(address _to, uint256 _genes, uint256 _charge)