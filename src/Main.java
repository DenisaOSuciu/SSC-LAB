import java.math.BigInteger;

// Daca decriptarile RSA modulo p=7 si q=13 sunt cp=2 si cp=5 cat e mesajul original?
//mesajul original e x

public class Main {


    public static void main(String[] args) {
        BigInteger p=new BigInteger("7");
        BigInteger q=new BigInteger("13");

        BigInteger cP=new BigInteger("2");
        BigInteger cQ=new BigInteger("5");

        BigInteger nP=p.multiply(q).divide(p);
        BigInteger nQ=q.multiply(p).divide(q);
        BigInteger n = p.multiply(q);



        BigInteger mP=nP.modInverse(p); //Mi= Ni ^(-1) * mod ni
        BigInteger mQ=nQ.modInverse(q);

        BigInteger sum=cP.multiply(nP).multiply(mP).add(cQ.multiply(nQ).multiply(mQ));
        BigInteger x =sum.mod(n); // (cp*Np*Mp + cq*Nq*mQ) mod (cp*cq)
        System.out.println(mP);
        System.out.println(mQ);
        System.out.println(x);
    }
}
