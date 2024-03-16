<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:IrisFlowChartEditor.IrisFlowChart" mode="modContent">
    <xsl:attribute name="Class">Common-FontData  IrisFlowChart-Control</xsl:attribute>
    <form id="{@ClientID}___Form" method="POST" vwgguid="{@Id}">
      <input type="hidden" id="{@ClientID}" name="{@UniqueID}" value="{@Attr.Value}"/>
      <input type="hidden" id="{@ClientID}___Config" value="{@Config}" />
      <flowchart id="{@ClientID}___Frame"></flowchart>
    </form>
  </xsl:template>

</xsl:stylesheet>