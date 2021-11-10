import java.math.BigInteger;

public class Main {

    public static void main(String [] args) {
        BigInteger n = new BigInteger("5076313634899413540120536350051034312987619378778911504647420938544" +
                "7465177110314901155284204273194792744073890582538974985571109131603" +
                "02801741874277608327");
        BigInteger e = new BigInteger("3");
        BigInteger d = new BigInteger("3384209089932942360080357566700689541991746252519274336431613959029" +
                "8310118072592266557861250508877279212747197519861041620378008076415" +
                "22348207376583379547");

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
