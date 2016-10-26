namespace whut.xljk.MODEL
{
    public class T_Article
    {
        //文章表的model类，对应属性，这里面使用类当属性来模仿主外键关系
        //C_ArticleId, C_ArticleTitle, C_ArticleSector, C_ArticleCategory, C_ArticleTopic, C_ArticleContent, C_ArticlePostStaff, C_ArticleAnnexAddr, C_ArticleTime
        
        //文章编号
        public string ArticleId{ get; set; }
        //文章名称
        public string ArticleTitle{ get; set; }
        //来源
        public string ArticleSector { get; set; }
        //文章类别
        public int ArticleCategory { get; set; }
        //文章主题--不用
        public T_Topic topic { get; set; }
        //不用
        public string ArticleColumn { get; set; }
        //文章内容
        public string ArticleContent { get; set; }
        //文章发布者
        public string ArticlePostStaff { get; set; }
        //文章附件
        public string ArticleAnnexAddr { get; set; }
        //发布时间
        public string ArticleTime { get; set; }
    }
}
