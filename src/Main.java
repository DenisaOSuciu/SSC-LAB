import java.math.BigInteger;

public class Main {

    public static void main(String[] args) {
	BigInteger n=new BigInteger("837210799");
    BigInteger e=new BigInteger("7");
    BigInteger d=new BigInteger("478341751");


    BigInteger k=d.multiply(e).subtract(BigInteger.ONE).divide(n).add(BigInteger.ONE);
    BigInteger in=d.multiply(e).subtract(BigInteger.ONE).divide(k);
    BigInteger pPLUSq=n.add(BigInteger.ONE).subtract(in);
    BigInteger f=new BigInteger("4");

    BigInteger delta=pPLUSq.multiply(pPLUSq).subtract(n.multiply(f));

    BigInteger p=pPLUSq.add(delta.sqrt()).divide(BigInteger.TWO);
    BigInteger q=pPLUSq.subtract(delta.sqrt()).divide(BigInteger.TWO);
   // System.out.println(k);
    //System.out.println(pPLUSq);
    System.out.println("delta = " +delta);
    System.out.println("p= " + p);
    System.out.println("q= "+ q);

    }
}
