pragma solidity ^0.8.17;

struct Token 
{
    uint256 genes;
    uint256 birthTime;
    uint256 parent1; 
    uint256 parent2; 
    uint8 charge;
    uint8 generation;
}

contract BreedScience {
    /// @dev given genes of token 1 & 2, return a genetic combination - may have a random factor
    /// @param token1 genes of mom
    /// @param token2 genes of dad
    /// @return the genes that are supposed to be passed down the child
    function mixGenes(uint256 tokenId1, Token memory token1, uint256 tokenId2, Token memory token2, uint256 targetBlock) external returns (Token memory){
        
        // todo some code
        return CreateToken(tokenId1, tokenId2, token1.genes, 3, 1);
    }

    function CreateToken(uint256 tokenId1, uint256 tokenId2, uint256 _genes, uint8 _charge, uint8 _generation) internal returns (Token memory) {
        return Token(
            {
                genes: _genes,
                birthTime: block.timestamp,
                parent1: tokenId1,
                parent2: tokenId2,
                charge: _charge,
                generation: _generation
            });
    }
}